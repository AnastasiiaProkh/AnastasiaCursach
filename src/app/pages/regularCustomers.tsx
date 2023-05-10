import { useState } from "react";
import MyTable from "../reusable/MyTable";
import regularCustomerService from "../services/regularCustomerService";
import { TRegularCustomer } from "../types";

const RegularCustomers = (): JSX.Element => {
  const [regularCustomers, setRegularCustomers] = useState<TRegularCustomer[]>(
    []
  );

  useState(() => {
    regularCustomerService.getAll().then(({ data }) => {
      setRegularCustomers(data);
    });
  });

  return (
    <>
      {regularCustomers.length > 0 && (
        <MyTable
          data={regularCustomers}
          onDeleteClick={(value) => {
            regularCustomerService.delete(value.id).then(({ data }) => {
              setRegularCustomers(data);
            });
          }}
          onEditClick={() => {}}
        />
      )}
    </>
  );
};

export default RegularCustomers;
