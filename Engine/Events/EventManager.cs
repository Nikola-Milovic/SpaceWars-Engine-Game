using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Engine.Events {
    public class EventHandler {

        //Todo maybe split events into different parts so not everyone listens to the same thing, Ie. input events, UI events etc
        private static EventHandler instance;

        //Singleton
        public static EventHandler Instance {
            get {
                if (instance != null) {
                    instance = new EventHandler ();
                }
                return instance;
            }
        }

        static Queue<IEvent> eventQueue = new Queue<IEvent> ();
        static List<EventListener> listeners = new List<EventListener> ();
        static List<EventListener> inputListeners = new List<EventListener> ();

        //Used to add event to the pool
        public void AddEvent (IEvent ev) {
            eventQueue.Enqueue (ev);
        }

        public void RegisterListener (EventListener listener) {
            if (listener is InputEventListener) {
                inputListeners.Add (listener);
            } else {
                listeners.Add (listener);
            }
        }

        public void UnregisterListener (EventListener listener) {
            if (listener is InputEventListener) {
                inputListeners.Remove (listener);
            } else {
                listeners.Remove (listener);
            }
        }

        //Dispatch an event to all listeners and if someone handled it, stop
        //divided into input events and other events
        private void DispatchEvents () {
            if (eventQueue.Count == 0) return;
            IEvent ev = eventQueue.Dequeue ();
            if (ev is InputEvent) {
                foreach (EventListener listener in inputListeners) {
                    if (ev.isHandeled) {
                        break;
                    }
                    listener.onEvent (ev);
                }
            } else {
                foreach (EventListener listener in listeners) {
                    if (ev.isHandeled) {
                        break;
                    }
                    listener.onEvent (ev);
                }
            }
        }

        public void Update () {
            DispatchEvents ();
        }

    }
}