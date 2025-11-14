using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitRuisseau
{
    public interface IProtocol
    {
        /// <summary>
        /// Get the list of all online mediatheque
        /// </summary>
        /// <returns>An array of mediatheque name/ip</returns>
        public string[] GetOnlineMediatheque();

        /// <summary>
        /// Send an "I'm online" message
        /// </summary>
        public void SayOnline();

        /// <summary>
        /// Ask for the catalog of a specific mediatheque
        /// </summary>
        /// <param name="name">The name/ip of the mediatheque</param>
        /// <returns>A list of songs</returns>
        public List<ISong> AskCatalog(string name);

        /// <summary>
        /// Send our catalog to a specific mediatheque
        /// </summary>
        /// <param name="name">The name/ip of the mediatheque</param>
        public void SendCatalog(string name);

        /// <summary>
        /// Download the media from a mediatheque
        /// </summary>
        /// <param name="startByte">The first byte you need</param>
        /// <param name="endByte">The last byte you need</param>
        /// <param name="name">The name/ip of the mediatheque</param>
        public void AskMedia(string name, int startByte, int endByte);

        /// <summary>
        /// Send the media to someone
        /// </summary>
        /// <param name="startByte">The first byte they need</param>
        /// <param name="endByte">The last byte they need</param>
        /// <param name="name">The name/ip of the mediatheque</param>
        public void SendMedia(string name, int startByte, int endByte);
    }
}
