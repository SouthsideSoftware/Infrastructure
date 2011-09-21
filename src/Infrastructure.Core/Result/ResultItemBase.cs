//using System;
//using System.Xml.Linq;

//namespace Infrastructure.Core.Result {
//    /// <summary>
//    /// A result item with an associated XML element
//    /// </summary>
//    public class ResultItemBase : ResultItem, IEquatable<ResultItemBase> {
//        /// <summary>
//        /// Create a new ResultItemBase
//        /// </summary>
//        /// <param name="resultCode">The result code.  Negative for errors.  Positive for warnings.  Value -1 is reserved for internal use.</param>
//        /// <param name="message"></param>
//        public ResultItemBase(int resultCode, string message)
//            : base(resultCode, message) {}

//        /// <summary>
//        /// Equality checking for IEquatable implementation (LINQ friendly).
//        /// </summary>
//        /// <param name="other">The ResultItemBase to compare to this instance.</param>
//        /// <returns>True if the members of this instance have the same values as the member of the other instance.</returns>
//        public bool Equals(ResultItemBase other) {
//            if (other == null) {
//                return false;
//            }
//            return Equals(other as ResultItem);
//        }

//        /// <summary>
//        /// Check equality with another object
//        /// </summary>
//        /// <param name="obj">The object to check</param>
//        /// <returns>True is the given object is a ResultItemBase and has the same member values
//        /// as this instance.</returns>
//        public override bool Equals(object obj) {
//            if (obj is ResultItemBase) {
//                return Equals(obj as ResultItemBase);
//            }
//            return base.Equals(obj);
//        }

//        /// <summary>
//        /// Gets the hash code. 
//        /// </summary>
//        public override int GetHashCode() {
//            return ResultCode.GetHashCode() ^ Message.GetHashCode();
//        }
//    }
//}