// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Microsoft.EntityFrameworkCore.TestUtilities.Xunit;

namespace Microsoft.EntityFrameworkCore.Query
{
    public abstract class ComplexNavigationsWeakQueryTestBase<TFixture> : ComplexNavigationsQueryTestBase<TFixture>
        where TFixture : ComplexNavigationsWeakQueryFixtureBase, new()
    {
        protected ComplexNavigationsWeakQueryTestBase(TFixture fixture)
            : base(fixture)
        {
        }

        [ConditionalFact(Skip = "issue #8248")]
        public override void Required_navigation_on_a_subquery_with_First_in_projection()
        {
            base.Required_navigation_on_a_subquery_with_First_in_projection();
        }

        [ConditionalFact(Skip = "issue #8526")]
        public override void Select_subquery_with_client_eval_and_navigation1()
        {
            base.Select_subquery_with_client_eval_and_navigation1();
        }

        // Naked instances not supported
        public override void Entity_equality_empty()
        {
        }

        public override void Key_equality_two_conditions_on_same_navigation()
        {
        }


        #region #8172 - One-to-many not supported yet

        public override void Where_navigation_property_to_collection_of_original_entity_type()
        {
        }

        public override void Navigations_compared_to_each_other1()
        {
        }

        public override void Navigations_compared_to_each_other2()
        {
        }

        public override void Navigations_compared_to_each_other3()
        {
        }

        public override void Navigations_compared_to_each_other4()
        {
        }

        public override void Navigations_compared_to_each_other5()
        {
        }

        public override void SelectMany_nested_navigation_property_required()
        {
        }

        public override void Multiple_SelectMany_calls()
        {
        }

        public override void SelectMany_with_navigation_filter_and_explicit_DefaultIfEmpty()
        {
        }

        public override void SelectMany_with_nested_navigation_and_explicit_DefaultIfEmpty()
        {
        }

        public override void Contains_with_subquery_optional_navigation_and_constant_item()
        {
        }

        public override void SelectMany_navigation_property_and_projection()
        {
        }

        public override void SelectMany_nested_navigation_property_optional_and_projection()
        {
        }

        public override void SelectMany_navigation_property_with_another_navigation_in_subquery()
        {
        }

        public override void SelectMany_with_navigation_and_explicit_DefaultIfEmpty()
        {
        }

        public override void SelectMany_navigation_property()
        {
        }

        public override void Select_nav_prop_collection_one_to_many_required()
        {
        }

        public override void Data_reader_is_closed_correct_number_of_times_for_include_queries_on_optional_navigations()
        {
        }

        public override void SelectMany_where_with_subquery()
        {
        }

        public override void Complex_query_with_optional_navigations_and_client_side_evaluation()
        {
        }

        public override void SelectMany_navigation_property_and_filter_before()
        {
        }

        public override void SelectMany_with_nested_navigation_filter_and_explicit_DefaultIfEmpty()
        {
        }

        public override void Multiple_SelectMany_with_navigation_and_explicit_DefaultIfEmpty()
        {
        }

        public override void Where_navigation_property_to_collection()
        {
        }

        public override void Where_navigation_property_to_collection2()
        {
        }

        public override void Where_on_multilevel_reference_in_subquery_with_outer_projection()
        {
        }

        public override void SelectMany_navigation_property_and_filter_after()
        {
        }

        public override void SelectMany_with_navigation_filter_paging_and_explicit_DefaultIfEmpty()
        {
        }

        // Self-ref not supported
        public override void Join_navigation_translated_to_subquery_self_ref()
        {
        }

        public override void Join_condition_optimizations_applied_correctly_when_anonymous_type_with_multiple_properties()
        {
        }

        public override void Multi_level_include_reads_key_values_from_data_reader_rather_than_incorrect_reader_deep_into_the_stack()
        {
        }

        public override void Join_condition_optimizations_applied_correctly_when_anonymous_type_with_single_property()
        {
        }

        public override void Navigation_filter_navigation_grouping_ordering_by_group_key()
        {
        }

        public override void Manually_created_left_join_propagates_nullability_to_navigations()
        {
        }

        public override void Optional_navigation_propagates_nullability_to_manually_created_left_join1()
        {
        }

        public override void Optional_navigation_propagates_nullability_to_manually_created_left_join2()
        {
        }

        public override void Project_collection_navigation()
        {
        }

        public override void Project_collection_navigation_nested()
        {
        }

        public override void Project_collection_navigation_using_ef_property()
        {
        }

        public override void Project_collection_navigation_nested_anonymous()
        {
        }

        public override void Project_collection_navigation_count()
        {
        }

        public override void Project_collection_navigation_composed()
        {
        }

        public override void Project_collection_and_root_entity()
        {
        }

        public override void Project_collection_and_include()
        {
        }

        public override void Project_navigation_and_collection()
        {
        }

        public override void Select_optional_navigation_property_string_concat()
        {
        }

        public override void SelectMany_subquery_with_custom_projection()
        {
        }

        public override void Null_check_in_anonymous_type_projection_should_not_be_removed()
        {
        }

        public override void Null_check_in_Dto_projection_should_not_be_removed()
        {
        }

        #endregion
    }
}
