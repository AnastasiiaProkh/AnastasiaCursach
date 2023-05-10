import { useState } from "react";
import MyTable from "../reusable/MyTable";
import refundService from "../services/refundService";
import { TRefund } from "../types";

const Refund = (): JSX.Element => {
  const [agencies, setAgecnies] = useState<TRefund[]>([]);

  useState(() => {
    refundService.getAll().then(({ data }) => {
      setAgecnies(data);
    });
  });

  return (
    <>
      {agencies.length > 0 && (
        <MyTable
          data={agencies}
          onDeleteClick={(value) => {
            refundService.delete(value.id).then(({ data }) => {
              setAgecnies(data);
            });
          }}
          onEditClick={() => {}}
        />
      )}
    </>
  );
};

export default Refund;
