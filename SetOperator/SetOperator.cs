using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetOperator
{
    delegate IEnumerable<string> SetOperatorDelegate(IEnumerable<string> a, IEnumerable<string> b);

    public static class SetOperator
    {
        public static IEnumerable<string> Do(string ope, IEnumerable<string> strs1, IEnumerable<string> strs2)
        {
            Dictionary<string, SetOperatorDelegate> opeLists = new Dictionary<string, SetOperatorDelegate>();
            opeLists.Add("union", (a, b) => a.Union(b));
            opeLists.Add("intersect", (a, b) => a.Intersect(b));
            opeLists.Add("except", (a, b) => a.Except(b));
            SetOperatorDelegate Xor = (a, b) =>
            {
                var union = a.Union(b);
                var intersect = a.Intersect(b);
                return union.Except(intersect);
            };
            opeLists.Add("xor", Xor);

            if(opeLists.TryGetValue(ope, out SetOperatorDelegate selectedOperation))
            {
                return selectedOperation(strs1, strs2);
            }
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Operation : " + ope + " is not implemented!");
            sb.Append("Supported operations are ");
            foreach(var opestr in opeLists.Keys)
            {
                sb.Append(opestr + ", ");
            }
            sb.AppendLine(".");
            throw new NotImplementedException(sb.ToString());

        }

    }
}
