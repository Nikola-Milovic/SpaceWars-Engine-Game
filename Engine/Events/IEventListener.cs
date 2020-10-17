namespace Engine.Events {

    //Everyone who wants to receive events should implement EventListener, the EventManager will notify everyone who subscribes, then they can check if it's the event they are looking for
    // and if it is, handle it

    //Will divide the interface into different ones, InputEventListener, UIEventListener and so on, giving me more flexibility and 
    // more options to optimize EventDispatching
    public interface EventListener {

        public abstract void onEvent (IEvent ev);

        public virtual void RegisterListener () {
            Engine.Globals.eventHandler.RegisterListener (this);
        }

        public virtual void UnregisterListener () {
            Engine.Globals.eventHandler.UnregisterListener (this);
        }

    }
}