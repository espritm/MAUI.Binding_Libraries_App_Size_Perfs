using System;
using Microsoft.Maui;
using Microsoft.Maui.Handlers;

namespace CommunicationTool.Views
{
    public partial class ComToolViewHandler 
    {
#if ANDROID || IOS || MACCATALYST
        public static IPropertyMapper<ComToolView, ComToolViewHandler> PropertyMapper = new PropertyMapper<ComToolView, ComToolViewHandler>(ViewHandler.ViewMapper)
        {
        };


        public static CommandMapper<ComToolView, ComToolViewHandler> CommandMapper = new CommandMapper<ComToolView, ComToolViewHandler>(ViewCommandMapper)
        {
        };


        float unbluViewWidth;
        float unbluViewHeight;

        public ComToolViewHandler(float width = 400, float height = 600) : base(PropertyMapper, CommandMapper)
        {
            unbluViewWidth = width;
            unbluViewHeight = height;
        }
#else
        public ComToolViewHandler(float width = 400, float height = 600)
        {
        }
#endif
    }
}

