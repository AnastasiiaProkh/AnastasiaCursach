import { useState } from "react";
import MyTable from "../reusable/MyTable";
import ticketService from "../services/ticketService";
import { TTicket } from "../types";

const Ticket = (): JSX.Element => {
  const [agencies, setAgecnies] = useState<TTicket[]>([]);

  useState(() => {
    ticketService.getAll().then(({ data }) => {
      setAgecnies(data);
    });
  });

  return (
    <>
      {agencies.length > 0 && (
        <MyTable
          data={agencies}
          onDeleteClick={(value) => {
            ticketService.delete(value.id).then(({ data }) => {
              setAgecnies(data);
            });
          }}
          onEditClick={() => {}}
        />
      )}
    </>
  );
};

export default Ticket;
