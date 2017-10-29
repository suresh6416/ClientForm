//-----------------------------------------------------------------------
// <copyright file="OperationResult.cs" company="SkoolBell">
//   Copyright (c) 2017 SkoolBell. All rights reserved.
// </copyright>
// <author>hsarraf</author>
// <createdOn>2017-1-19 5:26 PM</createdOn>
// <summary></summary>
//-----------------------------------------------------------------------
namespace ClientRequest.Models.Models
{
    /// <summary>
    /// Operation Result - Primarily used to send information back via JSON response.
    /// </summary>
    public class OperationResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OperationResult"/> class.
        /// </summary>
        public OperationResult()
        {
            Status = OperationStatus.SUCCESS;
        }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        /// <value>
        /// The error message.
        /// </value>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Gets or sets the error key.
        /// </summary>
        /// <value>
        /// The error key.
        /// </value>
        public string ErrorKey { get; set; }

        /// <summary>
        /// Gets or sets the redirect URL.
        /// </summary>
        /// <value>
        /// The redirect URL.
        /// </value>
        public string RedirectUrl { get; set; }
        
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public object Data { get; set; }
    }
}