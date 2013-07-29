using System.Html.Media.Graphics;
using System.Runtime.CompilerServices;

namespace MorseCode.CsJs.UI
{
	public static class CanvasContextExtensionMethods
	{
		[InstanceMethodOnFirstArgument]
		public static void BeginPath(this CanvasContext canvasContext)
		{
		}

		[InstanceMethodOnFirstArgument]
		public static void ClosePath(this CanvasContext canvasContext)
		{
		}

		[InstanceMethodOnFirstArgument]
		public static void Stroke(this CanvasContext canvasContext)
		{
		}

		[InlineCode("{canvasContext}.fillStyle = {fillStyle}")]
		public static void SetFillStyle(this CanvasContext canvasContext, object fillStyle)
		{
		}

		[InstanceMethodOnFirstArgument]
		public static void Fill(this CanvasContext canvasContext)
		{
		}

		[InstanceMethodOnFirstArgument]
		public static void MoveTo(this CanvasContext canvasContext, int x, int y)
		{
		}

		[InstanceMethodOnFirstArgument]
		public static void LineTo(this CanvasContext canvasContext, int x, int y)
		{
		}

		[InstanceMethodOnFirstArgument]
		public static void ClearRect(this CanvasContext canvasContext, int x, int y, int width, int height)
		{
		}
	}
}