﻿using GraphQL.Types;

namespace GraphQLRestaurantReservation.Type
{
    public class ReservationInputType : InputObjectGraphType
    {
        public ReservationInputType()
        {
            Field<IntGraphType>("id");
            Field<StringGraphType>("customername");
            Field<StringGraphType>("email");
            Field<StringGraphType>("phoneNumber");
            Field<IntGraphType>("partySize");
            Field<StringGraphType>("specialRequest");
            Field<DateGraphType>("reservationDate");
        }
    }
}
