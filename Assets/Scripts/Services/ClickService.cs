using System;

namespace Services
{
    public class ClickService
    {
        public Action ClickHandled = delegate { };

        public ClickService()
        {
            
        }

        public void InvokeClickEvent()
        {
            ClickHandled.Invoke();
        }
    }
}
