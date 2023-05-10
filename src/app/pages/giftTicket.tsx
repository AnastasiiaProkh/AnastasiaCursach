import { useState } from "react";
import MyTable from "../reusable/MyTable";
import giftTicketService from "../services/giftTicketService";
import { TGiftTicket } from "../types";

const GiftTicket = (): JSX.Element => {
  const [giftTickets, setGiftTickets] = useState<TGiftTicket[]>([]);

  useState(() => {
    giftTicketService.getAll().then(({ data }) => {
      setGiftTickets(data);
    });
  });

  return (
    <>
      {giftTickets.length > 0 && (
        <MyTable
          data={giftTickets}
          onDeleteClick={(value) => {
            giftTicketService.delete(value.giftTicketId).then(({ data }) => {
              setGiftTickets(data);
            });
          }}
          onEditClick={() => {}}
        />
      )}
    </>
  );
};

export default GiftTicket;
