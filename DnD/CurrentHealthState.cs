namespace DiscordAndDragons
{
    public class CurrentHealthState
    {
        public TransitionState TransitionState { get; set; }
        public State State { get; set; }
        public int CurrentSuccesses { get; set; }
        public int CurrentFailures { get; set; }

        public CurrentHealthState(State state, TransitionState transitionState, int successes, int failures)
        {
            State = state;
            TransitionState = transitionState;
            CurrentSuccesses = successes;
            CurrentFailures = failures;
        }

        public CurrentHealthState(int successes, int failures)
        {
            State = State.Stable;
            CurrentSuccesses = successes;
            CurrentFailures = failures;
        }

        public void UpdateCurrentHealthState(int successes, int failures)
        {
            var previousState = State;
            // if this previous state is stable 
            // set the current state to be unconscious
            CurrentSuccesses = successes;
            CurrentFailures = failures;

            if (CurrentSuccesses == 3)
                State = State.Stable;
            else if (CurrentFailures == 3)
                State = State.Dead;
            else
                State = State.Unconscious;

            DetermineTransitioningState(previousState);
        }

        private void DetermineTransitioningState(State previousState)
        {
            if (previousState == State.Stable && State == State.Unconscious)
                TransitionState = TransitionState.FallingUnconscious;
            else if (previousState == State.Unconscious && State == State.Dead || previousState == State.Stable && State == State.Dead)
                TransitionState = TransitionState.Dying;
            else if (previousState == State.Unconscious && State == State.Stable)
                TransitionState = TransitionState.BecomingStable;
            else if (previousState == State.Dead && State == State.Unconscious)
                TransitionState = TransitionState.RevivedButUnconscious;
            else if (previousState == State.Unconscious && State == State.Unconscious)
                TransitionState = TransitionState.RemainsUnconscious;
            // Can add more states (like being resurrected etc 
            // However for now we'll support the basics
        }
    }

    public enum TransitionState
    {
        RemainsUnconscious,
        BecomingStable, 
        FallingUnconscious, 
        RevivedButUnconscious,
        Dying
    }

    public enum State
    {
        Unconscious,
        Stable,
        Dead
    }
}