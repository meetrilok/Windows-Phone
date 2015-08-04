using PortableClassLibrary.Resources;

namespace PortableClassLibrary
{
    public class LocalizedStrings
    {
        public AppResources Loc
        {
            get { return loc; }
        }
        private readonly AppResources loc = new AppResources();
    }
}