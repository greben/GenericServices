﻿using System;
using System.Threading.Tasks;

namespace GenericServices
{

    public interface IActionDefnAsync<TOut, in TIn>
    {
        /// <summary>
        /// If true then the caller should call EF SubmitChanges if the method exited with status IsValid and
        /// it looks to see if the data part has a ICheckIfWarnings and if the WriteEvenIfWarning is false
        /// and there are warnings then it does not call SubmitChanges
        /// </summary>
        bool SubmitChangesOnSuccess { get; }

        /// <summary>
        /// This allows the action to configure what it supports, which then affects what the user sees
        /// Note: it must be a constant as it is read just after the action is created
        /// </summary>
        ActionFlags ActionConfig { get; }

        /// <summary>
        /// This controls the lower value sent back to reportProgress
        /// Lower and Upper bound are there to allow outer tasks to call inner tasks 
        /// to do part of the work and still report progress properly
        /// </summary>
        int LowerBound { get; set; }

        /// <summary>
        /// This controls the upper bound of the value sent back to reportProgress
        /// </summary>
        int UpperBound { get; set; }

        /// <summary>
        /// This is a general form of a method to be run
        /// </summary>
        /// <param name="actionComms">Action communication channel, can be null</param>
        /// <param name="actionData">setup data sent to the service </param>
        /// <returns></returns>
        Task<ISuccessOrErrors<TOut>> DoActionAsync(IActionComms actionComms, TIn actionData);

    }
}
