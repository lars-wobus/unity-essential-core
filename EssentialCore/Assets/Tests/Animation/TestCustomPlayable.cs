using Essential.Core.Animation;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.TestTools;
//using Assert = UnityEngine.Assertions.Assert;

namespace Tests.Animation
{
    public class TestCustomPlayable
    {
        private CustomPlayable Target { get; set; }
        private Playable DummyPlayable { get; set; }
        private FrameData DummyFrameData { get; set; }
        
        [SetUp]
        public void Setup()
        {
            Target = new CustomPlayable();
            DummyPlayable = new Playable();
            DummyFrameData = new FrameData();
        }
        
        [Test]
        public void Should_CallGraphStartedAction_When_PlayableWasEntered()
        {
            var actual = string.Empty;
            const string expected = "GraphStarted";
            
            Target.GraphStarted += () => actual = expected;

            Target.OnGraphStart(DummyPlayable);
            Assert.AreEqual(actual, expected);
        }
        
        [Test]
        public void Should_CallGraphStoppedAction_When_PlayableWasStopped()
        {
            var actual = string.Empty;
            const string expected = "GraphStopped";
            
            Target.GraphStopped += () => actual = expected;

            Target.OnGraphStop(DummyPlayable);
            Assert.AreEqual(actual, expected);
        }
        
        [Test]
        public void Should_CallBehaviourPlayedAction_When_PlayableWasStarted()
        {
            var actual = string.Empty;
            const string expected = "BehaviourPlayed";
            
            Target.BehaviourPlayed += () => actual = expected;

            Target.OnBehaviourPlay(DummyPlayable, DummyFrameData);
            Assert.AreEqual(actual, expected);
        }
        
        [Test]
        public void Should_CallBehaviourPausedAction_When_PlayableWasPaused()
        {
            var actual = string.Empty;
            const string expected = "BehaviourPaused";
            
            Target.BehaviourPaused += () => actual = expected;

            Target.OnBehaviourPause(DummyPlayable, DummyFrameData);
            Assert.AreEqual(actual, expected);
        }
        
        // TODO
        /*[Test]
        public void Should_CallProgressChangedAction_When_PrepareFrameWasCalled()
        {
            var actual = string.Empty;
            const string expected = "ProgressChanged";
            
            Target.ProgressChanged += (double progress) => actual = expected;

            Target.PrepareFrame(DummyPlayable, DummyFrameData);
            Assert.AreEqual(actual, expected);
        }*/
    }
}