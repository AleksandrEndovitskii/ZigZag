using System;
using Utils;

namespace Services
{
    public class ClickService : IInitializeble, IUnInitializeble
    {
        public Action ClickHandled = delegate { };

        public void Initialize()
        {

        }

        public void UnInitialize()
        {

        }

        public void InvokeClickEvent()
        {
            ClickHandled.Invoke();
        }
    }
}
