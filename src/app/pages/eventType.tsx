import { useFormik } from "formik";
import { useState, useEffect } from "react";
import { Button, Col, Modal, ModalBody, ModalHeader, Row } from "reactstrap";
import MyTable from "../reusable/MyTable";
import eventTypesService from "../services/eventTypeService";
import { TEventType } from "../types";

const EventTypes = (): JSX.Element => {
  const [eventTypes, setEventTypes] = useState<TEventType[]>([]);
  const [addModalOpen, setAddModalOpen] = useState<boolean>(false);

  useEffect(() => {
    eventTypesService.getAll().then(({ data }) => setEventTypes(data));
  }, []);

  const formik = useFormik<TEventType>({
    initialValues: { id: 0, etype: "" },
    onSubmit: (values) => {
      if (values.id === 0)
        eventTypesService
          .create(values)
          .then(({ data }) => setEventTypes(data));
      else
        eventTypesService.update(values).then(({ data }) => {
          setEventTypes(data);
        });
      setAddModalOpen(false);
    },
  });

  return (
    <>
      <Button onClick={() => setAddModalOpen(true)} className="w-100">
        Add record
      </Button>
      {eventTypes.length > 0 && (
        <MyTable
          data={eventTypes}
          onDeleteClick={(value) =>
            eventTypesService
              .delete(value.id)
              .then(({ data }) => setEventTypes(data))
          }
          onEditClick={(value) => {
            formik.setValues({ ...value });
            setAddModalOpen(true);
          }}
        />
      )}
      {addModalOpen && (
        <Modal isOpen={addModalOpen} className="text-dark">
          <ModalHeader>
            {formik.values.id > 0 ? "Edit position" : "Create position"}
          </ModalHeader>
          <ModalBody>
            <form onSubmit={formik.handleSubmit}>
              <Row>
                <Col>
                  <label htmlFor="etype" className="mb-2">
                    Event type name
                  </label>
                  <input
                    id="etype"
                    name="etype"
                    onChange={formik.handleChange}
                    value={formik.values.etype}
                    className="form-control"
                  ></input>
                </Col>
              </Row>
              <Row className="mt-4">
                <Col>
                  <Button type="submit">Submit</Button>
                </Col>
                <Col className="justify-content-end d-flex">
                  <Button
                    color="secondary"
                    onClick={() => setAddModalOpen(false)}
                  >
                    Cancel
                  </Button>
                </Col>
              </Row>
            </form>
          </ModalBody>
        </Modal>
      )}
    </>
  );
};

export default EventTypes;
