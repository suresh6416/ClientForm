//-----------------------------------------------------------------------
// <copyright file="OperationStatus.cs" company="SkoolBell">
//   Copyright (c) 2017 SkoolBell. All rights reserved.
// </copyright>
// <author>hsarraf</author>
// <createdOn>2017-1-19 6:13 PM</createdOn>
// <summary></summary>
//-----------------------------------------------------------------------
namespace ClientRequest.Models.Models
{
    /// <summary>
    /// Operation Status
    /// </summary>
    public sealed class OperationStatus
    {
        /// <summary>
        /// The success
        /// </summary>
        public const string SUCCESS = "Success";

        /// <summary>
        /// The error
        /// </summary>
        public const string ERROR = "Error";

        /// <summary>
        /// The business rule fail
        /// </summary>
        public const string BUSINESSRULEFAIL = "BusinessRuleFail";
    }
}