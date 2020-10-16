namespace Engine.Events {

    public abstract class IEvent {

        public bool isHandeled = false;

        public virtual void Handled () {
            isHandeled = true;
        }

    }

}