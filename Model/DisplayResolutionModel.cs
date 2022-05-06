using System.Drawing;

namespace lazy_manager.Model
{
    class DisplayResolutionModel
    {
        public Size displaySize { get; set; } // display (width, height)
        public bool isDisplayResolution { get; set; } = false; // true -> we know display info
        public double displayScale { get; set; } // display scale (배율)

        private DisplayResolutionModel() { }

        private static DisplayResolutionModel singletonDisplayResolutionModel;
        /// <summary>
        /// singleton pattern
        /// </summary>
        public static DisplayResolutionModel Instance()
        {
            if (singletonDisplayResolutionModel == null)
                singletonDisplayResolutionModel = new DisplayResolutionModel();
            
            return singletonDisplayResolutionModel;
        }
    }
}
