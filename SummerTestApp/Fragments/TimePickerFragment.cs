using System;
using Android.App;
using Android.OS;
using Android.Widget;
using Java.Util;

namespace SummerTestApp.Fragments
{
    public class TimePickerFragment : DialogFragment,
        TimePickerDialog.IOnTimeSetListener
    {
        public static readonly string TAG = "Y:" + typeof(TimePickerFragment).Name.ToUpper();

        Action<TimeSpan> _timeSelectedHandler = delegate { };

        public static TimePickerFragment NewInstance(Action<TimeSpan> onTimeSet)
        {
            var frag = new TimePickerFragment {_timeSelectedHandler = onTimeSet};
            return frag;
        }

        public override Dialog OnCreateDialog(Bundle savedInstanceState)
        {
            var c = Calendar.Instance;
            var hour = c.Get(CalendarField.HourOfDay);
            var minute = c.Get(CalendarField.Minute);

            var dialog = new TimePickerDialog(Activity,
                this,
                hour,
                minute,
                true);
            return dialog;
        }

        public void OnTimeSet(TimePicker view, int hourOfDay, int minute)
        {
            var selectedTime = new TimeSpan(hourOfDay, minute,00);
            _timeSelectedHandler(selectedTime);
        }
    }
}