using Task_0;

namespace Task_1
{
    [TrackingEntity]
    public class Test1
    {
        [TrackingProperty] private dynamic[] someMassive;

        [TrackingProperty(PropertyName = "Main property")]
        [TrackingProperty(PropertyName = "Favorite property")]
        public dynamic SomeProperty { get; set; }

        [TrackingProperty(PropertyName = "Once again")]
        public dynamic SomePropertyAgain { get; set; }

        [TrackingProperty] public dynamic LastProperty { get; set; }
    }


    [TrackingEntity]
    public class Test2
    {
        private dynamic[] someMassive;

        public dynamic SomeProperty { get; set; }

        public dynamic SomePropertyAgain { get; set; }

        public dynamic LastProperty { get; set; }
    }
}