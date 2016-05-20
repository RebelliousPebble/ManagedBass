namespace ManagedBass.Fx
{
    /// <summary>
    /// BassFx AutoWah Effect.
    /// </summary>
    /// <remarks>
    /// <para>The effect implements the auto-wah by using 4-stage phaser effect which moves a peak in the frequency response up and down the frequency spectrum by amplitude of Input signal.</para>
    /// <para>
    /// The <see cref="DryMix"/> is the volume of Input signal and the <see cref="WetMix"/> is the volume of delayed signal.
    /// The <see cref="Feedback"/> sets feedback of auto wah (phaser).
    /// The <see cref="Rate"/> and <see cref="Range"/> control how fast and far the frequency notches move.
    /// The <see cref="Rate"/> is the rate of sweep in cycles per second, <see cref="Range"/> is the width of sweep in octaves.
    /// And the the <see cref="Frequency"/> is the base frequency of sweep.
    /// </para>
    /// </remarks>
    public sealed class AutoWahEffect : Effect<AutoWahParameters>
    {
        /// <summary>
        /// Creates a new instance of <see cref="AutoWahEffect"/>.
        /// </summary>
        /// <param name="Channel">The <paramref name="Channel"/> to apply the effect on.</param>
        /// <param name="Priority">Priority of the Effect... default = 0.</param>
        public AutoWahEffect(int Channel, int Priority = 0) : base(Channel, Priority) { }

        /// <summary>
        /// Creates a new instance of <see cref="AutoWahEffect"/> supporting <see cref="MediaPlayer"/>'s persistence.
        /// </summary>
        /// <param name="Player">The <see cref="MediaPlayer"/> to apply the effect on.</param>
        /// <param name="Priority">Priority of the Effect... default = 0.</param>
        public AutoWahEffect(MediaPlayer Player, int Priority = 0) : base(Player, Priority) { }

        #region Presets
        /// <summary>
        /// Set up a Preset.
        /// </summary>
        public void Slow()
        {
            Parameters.fDryMix = 0.5f;
            Parameters.fWetMix = 1.5f;
            Parameters.fFeedback = 0.5f;
            Parameters.fRate = 2;
            Parameters.fRange = 4.3f;
            Parameters.fFreq = 50;

            OnPropertyChanged("");
        }

        /// <summary>
        /// Set up a Preset.
        /// </summary>
        public void Fast()
        {
            Parameters.fDryMix = 0.5f;
            Parameters.fWetMix = 1.5f;
            Parameters.fFeedback = 0.5f;
            Parameters.fRate = 5;
            Parameters.fRange = 5.3f;
            Parameters.fFreq = 50;

            OnPropertyChanged("");
        }

        /// <summary>
        /// Set up a Preset.
        /// </summary>
        public void HiFast()
        {
            Parameters.fDryMix = 0.5f;
            Parameters.fWetMix = 1.5f;
            Parameters.fFeedback = 0.5f;
            Parameters.fRate = 5;
            Parameters.fRange = 4.3f;
            Parameters.fFreq = 500;

            OnPropertyChanged("");
        }
        #endregion

        /// <summary>
        /// Dry (unaffected) signal mix (-2...+2). Default = 0.5.
        /// </summary>
        public double DryMix
        {
            get { return Parameters.fDryMix; }
            set
            {
                Parameters.fDryMix = (float)value;

                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Feedback (-1...+1). Default = 0.5.
        /// </summary>
        public double Feedback
        {
            get { return Parameters.fFeedback; }
            set
            {
                Parameters.fFeedback = (float)value;

                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Base frequency of sweep range (0&lt;...1000). Default = 50.
        /// </summary>
        public double Frequency
        {
            get { return Parameters.fFreq; }
            set
            {
                Parameters.fFreq = (float)value;

                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Sweep range in octaves (0&lt;...&lt;10). Default = 4.3.
        /// </summary>
        public double Range
        {
            get { return Parameters.fRange; }
            set
            {
                Parameters.fRange = (float)value;

                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Rate of sweep in cycles per second (0&lt;...&lt;10). Default = 2.
        /// </summary>
        public double Rate
        {
            get { return Parameters.fRate; }
            set
            {
                Parameters.fRate = (float)value;

                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Wet (affected) signal mix (-2...+2). Default = 1.5.
        /// </summary>
        public double WetMix
        {
            get { return Parameters.fWetMix; }
            set
            {
                Parameters.fWetMix = (float)value;

                OnPropertyChanged();
            }
        }

        /// <summary>
        /// A <see cref="FXChannelFlags" /> flag to define on which channels to apply the effect. Default: <see cref="FXChannelFlags.All"/>
        /// </summary>
        public FXChannelFlags Channels
        {
            get { return Parameters.lChannel; }
            set
            {
                Parameters.lChannel = value;

                OnPropertyChanged();
            }
        }
    }
}