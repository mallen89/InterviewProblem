using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewProblem
{
    public enum AlarmState
    {
        /// <summary>
        /// Indicates device alarm when channel reading has gone out of the Min/Max range
        /// </summary>
        AlarmOut = 0,

        /// <summary>
        /// Indicates device alarm when channel reading has returned within the Min/Max range
        /// </summary>
        AlarmIn,

        /// <summary>
        /// Indicates that an alarm has been acknowledged on the device
        /// </summary>
        AlarmAcknowledge,

        /// <summary>
        /// Indicates a low battery alarm
        /// </summary>
        LowBattery,

        /// <summary>
        /// Indicates a potential lost connectivity condition. This alarm is thrown
        /// by the cloud service after 2 missed update intervals.
        /// </summary>
        LostConnectivity,

        /// <summary>
        /// Indicates no alarm on the channel
        /// </summary>
        NoAlarm,

        /// <summary>
        /// Indicates when channel reading has exceeded the device Max alarm setting
        /// </summary>
        MaxAlarmOut = 6,

        /// <summary>
        /// Indicates when channel reading has exceeded the device Min alaram setting
        /// </summary>
        MinAlarmOut = 7,

        /// <summary>
        /// Indicates when the channel reading has reentered the valid range from outside the upper bound
        /// </summary>
        MaxAlarmIn = 8,

        /// <summary>
        /// Indicates when the channel reading has reentered the valid range from outside the lower bound
        /// </summary>
        MinAlarmIn = 9,

        /// <summary>
        /// Indicates when device connectivity is restored
        /// </summary>
        ConnectvityRestored,

        /// <summary>
        /// Indicates when a channel's alarm setting has been changed
        /// </summary>
        SettingChanged,

        /// <summary>
        /// Indicates that a user has physically checked the device by pushing the alarm acknowledge button
        /// while the device is not in alarm.
        /// </summary>
        DeviceChecked,

        /// <summary>
        /// Indicates that a user has pushed the start button on a non-connected logging device to commence data logging
        /// </summary>
        LoggingStarted,
    }
}
