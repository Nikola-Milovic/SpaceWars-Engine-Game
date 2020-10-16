using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Engine.Events {
    public class EventHandler {

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

        //Used to add event to the pool
        public void AddEvent (IEvent ev) {
            eventQueue.Enqueue (ev);
        }

        private void DispatchEvents () {
            if (eventQueue.Count == 0) return;
            foreach (EventListener listener in listeners) {
                listener.onEvent (eventQueue.Dequeue ());
            }
        }

        public void Update () {
            DispatchEvents ();
        }

    }
}