using System;
using System.Collections.Generic;
using System.Linq;
using Infrastructure.Core.CodeContracts;

namespace Infrastructure.Core.Result
{
    /// <summary>
    /// A collection of result items.
    /// </summary>
    [Serializable]
    public class ResultItemCollection
    {
        /// <summary>
        /// The collection of result items.
        /// </summary>
        protected List<ResultItem> _resultItems = new List<ResultItem>();

        /// <summary>
        /// Returns true if there are no errors in the errors collection.
        /// </summary>
        public bool IsSuccess { get { return Errors.Count == 0; } }

        /// <summary>
        /// Gets a read-only list of the errors
        /// </summary>
        public IList<ResultItem> Errors { get { return _resultItems.Where(m => m.Type == ResultItemType.Error).ToList().AsReadOnly(); } }

        /// <summary>
        /// Gets a read-only list of the warnings
        /// </summary>
        public IList<ResultItem> Warnings { get { return _resultItems.Where(m => m.Type == ResultItemType.Warning).ToList().AsReadOnly(); } }

        /// <summary>
        /// Gets a read-only list of all result items
        /// </summary>
        public IList<ResultItem> Messages { get { return _resultItems.ToList().AsReadOnly(); } }

        /// <summary>
        /// Get the count of all errors and warnings.
        /// </summary>
        public int Count { get { return Messages.Count; } }

        /// <summary>
        /// Adds a result item that may be an error or a warning.
        /// </summary>
        /// <param name="resultItem">The message to add.</param>
        public void AddMessage(ResultItem resultItem)
        {
            ParameterCheck.ParameterRequired(resultItem, "message");
            if (!_resultItems.Contains(resultItem)) _resultItems.Add(resultItem);
        }

        /// <summary>
        /// Append errors and warnings to this collection.
        /// </summary>
        /// <param name="resultToAppend">The object containing errors and warnings to add.</param>
        public void AppendResult(ResultItemCollection resultToAppend)
        {
            ParameterCheck.ParameterRequired(resultToAppend, "resultToAppend");

            AddMessages(resultToAppend.Messages);
        }

        /// <summary>
        /// Add all unique warning from an IEnumerable{ResultItem}
        /// </summary>
        /// <param name="messages">IEnumerable{ResultItem} containing items to add</param>
        public void AddMessages(IEnumerable<ResultItem> messages)
        {
            ParameterCheck.ParameterRequired(messages, "messages");

            foreach (var message in messages)
            {
                AddMessage(message);
            }
        }

        /// <summary>
        /// Returns a string representation of the result.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (_resultItems.Count > 0)
            {
                return string.Format("IsSuccess = {0} Messages: {1}", IsSuccess, string.Join(", ", _resultItems));
            }
            return string.Format("IsSuccess = {0}", IsSuccess);
        }

        /// <summary>
        /// Returns a string representation of the result.
        /// </summary>
        /// <returns></returns>
        public string ToStringWithLineBreaks()
        {
            if (_resultItems.Count > 0)
            {
                return string.Format("IsSuccess = {0} Messages:\n{1}", IsSuccess, string.Join("\n", _resultItems));
            }
            return string.Format("IsSuccess = {0}", IsSuccess);
        }

        /// <summary>
        /// Returns an HTML string representation of the result.
        /// </summary>
        /// <returns></returns>
        public string ToHtml()
        {
            if (_resultItems.Count > 0)
            {
                return string.Format(@"IsSuccess = {0} 
Messages: {1}", IsSuccess, string.Join(@"
", _resultItems));
            }
            return string.Format("IsSuccess = {0}", IsSuccess);
        }
    }
}
