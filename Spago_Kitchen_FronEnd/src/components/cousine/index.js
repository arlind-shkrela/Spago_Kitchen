import React, { useEffect } from "react";
import AssignmentIcon from "@material-ui/icons/Assignment";
import PageHeader from "../shared/PageHeader";

export default function IndexCousine(props) {
  useEffect(() => {
    if(!props.fetched) {
        props.fetchRules();
    }
    console.log('mount it!');
}); // passing an empty array as second argument triggers the callback in useEffect only after the initial render thus replicating `componentDidMount` lifecycle behaviour

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
