namespace Engine.Events {
    public interface EventListener {

        //Everyone who wants to receive events should implement EventListener, the EventManager will notify everyone who subscribes, then they can check if it's the event they are looking for
        // and if it is, handle it
        public abstract void onEvent (IEvent ev);

        public virtual void RegisterListener () {
            Engine.Globals.eventHandler.RegisterListener (this);
        }

        public virtual void UnregisterListener () {
            Engine.Globals.eventHandler.UnregisterListener (this);
        }

    }
}