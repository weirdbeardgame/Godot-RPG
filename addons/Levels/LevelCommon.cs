using Godot;
using System;
using Godot.Collections;


namespace Levels
{
    public partial class LevelCommon : Node
    {
        [Export]
        public string LevelName;

        // Used for Pausing
        bool _isActive;

        public Camera2D Camera;

        public ILevelData Data { get; protected set; }

        protected Player Player;
        protected void SetIsActive(bool state) => _isActive = state;

        AudioStreamPlayer _backgroundPlayer;

        [Export] Resource audioFile;

        bool unlocked;
        bool complete;

        public bool isComplete
        {
            get
            {
                return complete;
            }
        }

        public bool isUnlocked
        {
            get
            {
                return unlocked;
            }
        }

        public virtual void EnterLevel()
        {
            _backgroundPlayer = (AudioStreamPlayer)GetNode("BackgroundAudio");
            CreateAudioStream();
            SetIsActive(true);
        }

        public void CreateAudioStream()
        {
            _backgroundPlayer.Stream = GD.Load<AudioStream>(audioFile.ResourcePath);
            _backgroundPlayer.Play();
        }

        public void CompleteLevel()
        {
            complete = true;
            ExitLevel();
        }

        public virtual void Update()
        {

        }

        public virtual void FixedUpdate()
        {

        }

        public override void _Process(double delta)
        {
            base._Process(delta);
            // Since these are Tool scripts IE. Allowed to run in the editor, we need to ensure logic that's borked outside the editor doesn't run
#if !(TOOLS)
        Update();
#endif
        }

        public override void _PhysicsProcess(double delta)
        {
            base._PhysicsProcess(delta);
#if !(TOOLS)
        FixedUpdate();
#endif

        }

        public virtual void ExitLevel()
        {

        }

        public virtual void CalledDefferedExitLevel()
        {

        }

        public virtual void ResetLevel()
        {

        }

        public virtual void EnterSubLevel(Player Player, SubLevel parent)
        {

        }

        public virtual void ExitSubLevel()
        {

        }
    }
}