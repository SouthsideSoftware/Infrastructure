using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;

namespace Infrastructure.Core.Result
{
    /// <summary>
    /// A result that includes a list of error and warnings and
    /// a return object.  The return object may be null.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public class ResultOf<T> : ResultItemCollection
        where T : class
    {
        /// <summary>
        /// The wrapped value.
        /// </summary>
        public T Value { get; private set; }

        /// <summary>
        /// Indicate if the wrapped value is present.
        /// </summary>
        public bool HasValue { get { return Value != null; } }

        /// <summary>
        /// Create an empty result.
        /// </summary>
        public ResultOf()
        {
            Value = null;
        }

        /// <summary>
        /// Create a result with a value.
        /// </summary>
        /// <param name="value"></param>
        public ResultOf(T value)
        {
            Value = value;
        }

        /// <summary>
        /// Create a result from a result item collection
        /// </summary>
        /// <param name="messages"></param>
        public ResultOf(ResultItemCollection messages)
        {
            ParameterCheck.ParameterRequired(messages, "messages");
            Value = null;
            AppendResult(messages);
        }

        /// <summary>
        /// Create a result from a set of messages
        /// </summary>
        /// <param name="messages"></param>
        public ResultOf(IEnumerable<ResultItem> messages)
        {
            ParameterCheck.ParameterRequired(messages, "messages");
            Value = null;
            AddMessages(messages);
        }

        /// <summary>
        /// Create a result from a single result item
        /// </summary>
        /// <param name="resultItem"></param>
        public ResultOf(ResultItem resultItem)
        {
            ParameterCheck.ParameterRequired(resultItem, "resultItem");
            Value = null;
            AddMessage(resultItem);
        }

        /// <summary>
        /// Create with a value and  a collection of result items.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="resultItems"></param>
        public ResultOf(T value, ResultItemCollection resultItems)
        {
            ParameterCheck.ParameterRequired(resultItems, "resultItems");
            Value = value;
            AppendResult(resultItems);
        }

        /// <summary>
        /// Gets a string representation of this result.  Includes
        /// a string representation of the value if the value is
        /// non-null.
        /// </summary>
        public override string ToString()
        {
            return string.Format("Value: {0} Result: {1}", HasValue ? Value.ToString() : "NULL", base.ToString());
        }
    }
}
