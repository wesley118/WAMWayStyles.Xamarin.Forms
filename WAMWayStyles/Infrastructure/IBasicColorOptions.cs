using Xamarin.Forms;

namespace WAMWayStyles.Infrastructure
{
    public interface IBasicColorOptions
    {
        Color ButtonColor { get; }
        Color DefaultTextColor { get; }
        Color HeaderTextColor { get; }
        Color ButtonTextColor { get; }
        Color DefaultBackgroundColor { get; }
        Color DefaultAccentColor { get; }
        Color DefaultPlaceholderTextColor { get; }
        Color EntryBackgroundColor { get; }
    }
}
