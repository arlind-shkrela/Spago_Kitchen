import React from "react";
import AssignmentIcon from "@material-ui/icons/Assignment";
import PageHeader from "../PageHeader";

export default function IndexCousine() {
  return (
    <>
      <PageHeader
        title="Cousine"
        subtitle="This is our cousine"
        icon={<AssignmentIcon fontSize="large" />}
      ></PageHeader>
    </>
  );
}
