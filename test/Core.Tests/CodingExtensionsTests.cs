using Microsoft.VisualStudio.TestTools.UnitTesting;
using MutatorFX.Coding;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Tests
{
    [TestClass]
    public class CodingExtensionsTests
    {
        public List<int> List { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            List = new List<int>(Enumerable.Range(1, 50));
        }

        [TestMethod]
        public void DoWorks()
        {
            var list2 = List.Do(e => e.Add(4));
            Assert.AreEqual(List, list2);
        }

        [TestMethod]
        public async Task DoAsyncWorks()
        {
            var sum = 0;
            var task = List.DoAsync(async e => { await Task.Delay(100); sum = e.Sum(); });
            await Task.Delay(10);
            Assert.IsTrue(sum == 0);
            await task;
            Assert.IsTrue(sum == 1275);
        }

        [TestMethod]
        public void PipeWorks()
        {
            var list2 = List.Pipe(e => e.Where(x => x % 2 == 0).ToList());
            Assert.IsTrue(List.Count == 50);
            Assert.IsTrue(list2.Count == 25);
        }

        [TestMethod]
        public async Task PipeAsyncWorks()
        {
            Assert.AreEqual(await List.PipeAsync(async e => { await Task.Delay(100); return e.Sum(); }), 1275);
        }

        [TestMethod]
        public void BranchActionWorks()
        {
            (bool ifRan, bool elseRan, List<int> retval) IfElse(Func<List<int>, bool> predicate, Action<List<int>> actionIf, Action<List<int>> actionElse)
            {
                var (ifRan, elseRan) = (false, false);
                var retVal = List.Branch(predicate, actionIf != null ? e => { actionIf(e); ifRan = true; } : (Action<List<int>>)null, actionElse != null ? e => { actionElse(e); elseRan = true; } : (Action<List<int>>)null);
                return (ifRan, elseRan, retVal);
            }
            var (countIf, countElse) = (0, 0);
            Assert.AreEqual((true, false, List), IfElse(l => l.Count == 50, l => countIf = l.Count, null));
            Assert.AreEqual(countIf, 50);

            (countIf, countElse) = (0, 0);
            Assert.AreEqual((false, false, List), IfElse(l => l.Count < 50, l => countIf = l.Count, null));
            Assert.AreEqual(countIf, 0);

            (countIf, countElse) = (0, 0);
            Assert.AreEqual((false, true, List), IfElse(l => l.Count > 50, l => countIf = l.Count, l => countElse = l.Count));
            Assert.AreEqual((countIf, countElse), (0, 50));
        }

        [TestMethod]
        public void BranchFuncWorks()
        {
            (bool ifRan, bool elseRan, TResult retval) IfElse<TResult>(Func<List<int>, bool> predicate, Func<List<int>, TResult> actionIf, Func<List<int>, TResult> actionElse)
            {
                var (ifRan, elseRan) = (false, false);
                var retVal = List.Branch(predicate, actionIf != null ? e => { ifRan = true; return actionIf(e); } : (Func<List<int>, TResult>)null, actionElse != null ? e => { elseRan = true; return actionElse(e); } : (Func<List<int>, TResult>)null);
                return (ifRan, elseRan, retVal);
            }

            var (countIf, countElse) = (0, 0);
            Assert.AreEqual((true, false, 50), IfElse(l => l.Count == 50, l => countIf = l.Count, null));
            Assert.AreEqual(countIf, 50);

            (countIf, countElse) = (0, 0);
            Assert.AreEqual((false, false, 0), IfElse(l => l.Count < 50, l => countIf = l.Count, null));
            Assert.AreEqual(countIf, 0);

            (countIf, countElse) = (0, 0);
            Assert.AreEqual((false, true, 50), IfElse(l => l.Count > 50, l => countIf = l.Count, l => countElse = l.Count));
            Assert.AreEqual((countIf, countElse), (0, 50));
        }

        [TestMethod]
        public async Task BranchAsyncActionWorks()
        {
            var (ifRan, elseRan) = (false, false);
            var retVal = await List.BranchAsync(l => Task.FromResult(l.Count == 50), async l => { await Task.Delay(100); ifRan = true; });
            Assert.AreEqual((true, false, List), (ifRan, elseRan, retVal));

            (ifRan, elseRan) = (false, false);
            retVal = await List.BranchAsync(async l => await Task.FromResult(l.Count > 50), async l => { await Task.Delay(100); ifRan = true; });
            Assert.AreEqual((false, false, List), (ifRan, elseRan, retVal));

            (ifRan, elseRan) = (false, false);
            retVal = await List.BranchAsync(async l => await Task.FromResult(l.Count > 50), async l => { await Task.Delay(100); ifRan = true; }, async l => await Task.FromResult(elseRan = true));
            Assert.AreEqual((false, true, List), (ifRan, elseRan, retVal));
        }

        [TestMethod]
        public async Task BranchAsyncFuncWorks()
        {
            var (ifRan, elseRan) = (false, false);
            var retVal1 = await List.BranchAsync(l => Task.FromResult(l.Count == 50), async l => { await Task.Delay(100); return ifRan = true; });
            Assert.AreEqual((true, false, true), (ifRan, elseRan, retVal1));

            (ifRan, elseRan) = (false, false);
            var retVal2 = await List.BranchAsync(async l => await Task.FromResult(l.Count > 50), async l => { await Task.Delay(100); return l.Count; });
            Assert.AreEqual((false, false, 0), (ifRan, elseRan, retVal2));

            (ifRan, elseRan) = (false, false);
            var retVal3 = await List.BranchAsync(async l => await Task.FromResult(l.Count > 50), async l => { await Task.Delay(100); ifRan = true; return l.Count; }, async l => { elseRan = true; return await Task.FromResult(l.Count); });
            Assert.AreEqual((false, true, 50), (ifRan, elseRan, retVal3));
        }
    }
}