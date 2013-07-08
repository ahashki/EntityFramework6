// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace System.Data.Entity.ModelConfiguration.Configuration
{
    using System.ComponentModel;
    using System.Data.Entity.ModelConfiguration.Configuration.Properties.Navigation;
    using System.Data.Entity.Utilities;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    ///     Configures a relationship that can only support foreign key properties that are not exposed in the object model.
    ///     This configuration functionality is available via the Code First Fluent API, see <see cref="DbModelBuilder" />.
    /// </summary>
    public class ForeignKeyNavigationPropertyConfiguration : CascadableNavigationPropertyConfiguration
    {
        internal ForeignKeyNavigationPropertyConfiguration(
            NavigationPropertyConfiguration navigationPropertyConfiguration)
            : base(navigationPropertyConfiguration)
        {
        }

        /// <summary>
        ///     Configures the relationship to use foreign key property(s) that are not exposed in the object model.
        ///     The column(s) and table can be customized by specifying a configuration action.
        ///     If an empty configuration action is specified then column name(s) will be generated by convention.
        ///     If foreign key properties are exposed in the object model then use the HasForeignKey method.
        ///     Not all relationships support exposing foreign key properties in the object model.
        /// </summary>
        /// <param name="configurationAction"> Action that configures the foreign key column(s) and table. </param>
        /// <returns> A configuration object that can be used to further configure the relationship. </returns>
        public CascadableNavigationPropertyConfiguration Map(
            Action<ForeignKeyAssociationMappingConfiguration> configurationAction)
        {
            Check.NotNull(configurationAction, "configurationAction");

            NavigationPropertyConfiguration.Constraint = IndependentConstraintConfiguration.Instance;

            var independentAssociationMappingConfiguration = new ForeignKeyAssociationMappingConfiguration();

            configurationAction(independentAssociationMappingConfiguration);

            NavigationPropertyConfiguration.AssociationMappingConfiguration = independentAssociationMappingConfiguration;

            return this;
        }

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString()
        {
            return base.ToString();
        }

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <inheritdoc />
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Type GetType()
        {
            return base.GetType();
        }
    }
}
