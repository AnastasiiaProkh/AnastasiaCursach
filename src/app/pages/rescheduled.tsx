import { useState } from "react";
import MyTable from "../reusable/MyTable";
import rescheduledService from "../services/rescheduledService";
import { TRescheduled } from "../types";

const Rescheduled = (): JSX.Element => {
  const [rescheduledEvents, setRescheduledEvents] = useState<TRescheduled[]>(
    []
  );

  useState(() => {
    rescheduledService.getAll().then(({ data }) => {
      setRescheduledEvents(data);
    });
  });

  return (
    <>
      {rescheduledEvents.length > 0 && (
        <MyTable
          data={rescheduledEvents}
          onDeleteClick={(value) => {
            rescheduledService.delete(value.id).then(({ data }) => {
              setRescheduledEvents(data);
            });
          }}
          onEditClick={() => {}}
        />
      )}
    </>
  );
};

export default Rescheduled;
