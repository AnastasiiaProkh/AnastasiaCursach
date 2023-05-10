import { useFormik } from "formik";
import { useState } from "react";
import MyTable from "../reusable/MyTable";
import eventService from "../services/eventService";
import { TEvent, TEventType } from "../types";

const Events = (): JSX.Element => {
  const [events, setEvents] = useState<TEvent[]>([]);
  const [addModalOpen, setAddModalOpen] = useState<boolean>(false);
  const [eventTypes, setEventsTypes] = useState<TEventType[]>([]);

  useState(() => {
    eventService.getAll().then(({ data }) => {
      setEvents(data);
    });
  });

  const formik = useFormik<TEvent>({
    initialValues: { id: 0, ename: "", etype: 0, edate: "" },
    onSubmit: (values) => {
      if (values.id > 0)
        eventService.update(values).then(({ data }) => {
          setEvents(data);
        });
      else {
        eventService.create(values).then(({ data }) => {
          setEvents(data);
        });
      }
      setAddModalOpen(false);
    },
  });

  return (
    <>
      {events.length > 0 && (
        <MyTable
          data={events}
          onDeleteClick={(value) => {
            eventService.delete(value.id).then(({ data }) => {
              setEvents(data);
            });
          }}
          onEditClick={() => {}}
        />
      )}
    </>
  );
};

export default Events;
