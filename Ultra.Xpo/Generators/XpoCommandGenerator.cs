using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;

public static class XpoCommandGenerator
{
    public static ModificationStatement GenerateModificationCommand<T>(Session session, Dictionary<string, object> values) where T : XPBaseObject
    {
        XPClassInfo classInfo = session.GetClassInfo<T>();
        DBTable table = classInfo.Table;
        string alias = table.Name; // Assuming the alias is the same as the table name

        // Determine if we are updating an existing object or creating a new one
        bool isNewObject = !values.ContainsKey(classInfo.KeyProperty.Name) || values[classInfo.KeyProperty.Name] == null;

        ModificationStatement statement;

        if (isNewObject)
        {
            // Create an InsertStatement with the correct constructor
            InsertStatement insertStatement = new InsertStatement(table, alias);
            foreach (var pair in values)
            {
                //insertStatement.Operands.Add(new OperandParameter(pair.Key, pair.Value));
                //insertStatement.Parameters.Add(new OperandValue(pair.Key));
                insertStatement.Operands.Add(new OperandValue(pair.Value));
                insertStatement.Parameters.Add(new OperandParameter(pair.Key, pair.Value));
            }
            statement = insertStatement;
        }
        else
        {
            // Create an UpdateStatement
            UpdateStatement updateStatement = new UpdateStatement(table, alias);
            foreach (var pair in values)
            {
                if (pair.Key == classInfo.KeyProperty.Name)
                {
                    // Set the condition for the update (i.e., where the key equals the given value)
                    updateStatement.Condition = new BinaryOperator(pair.Key, pair.Value, BinaryOperatorType.Equal);
                }
                else
                {
                    updateStatement.Operands.Add(new OperandParameter(pair.Key, pair.Value));
                  
                }
            }
            statement = updateStatement;
        }

        return statement;
    }
}
