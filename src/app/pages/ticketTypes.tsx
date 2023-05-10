import { useFormik } from "formik";
import { useEffect, useState } from "react";
import { Button, Col, Modal, ModalBody, ModalHeader, Row } from "reactstrap";
import MyTable from "../reusable/MyTable";
import ticketTypeService from "../services/ticketTypeService";
import { TTicketType } from "../types";

const TicketTypes = (): JSX.Element => {
  const [ticketTypes, setTicketTypes] = useState<TTicketType[]>([]);
  const [addModalOpen, setAddModalOpen] = useState<boolean>(false);

  useEffect(() => {
    ticketTypeService.getAll().then(({ data }) => {
      setTicketTypes(data);
    });
  }, []);

  const formik = useFormik<TTicketType>({
    initialValues: { id: 0, ttype: "" },
    onSubmit: (values) => {
      if (values.id === 0)
        ticketTypeService
          .create(values)
          .then(({ data }) => setTicketTypes(data));
      else
        ticketTypeService
          .update(values)
          .then(({ data }) => setTicketTypes(data));
      formik.setValues({ ...formik.initialValues });
      setAddModalOpen(false);
    },
  });

  return (
    <>
      <Button onClick={() => setAddModalOpen(true)} className="w-100">
        Add record
      </Button>
      {ticketTypes.length > 0 && (
        <MyTable
          data={ticketTypes}
          onEditClick={(value) => {
            formik.setValues({ ...value });
            setAddModalOpen(true);
          }}
          onDeleteClick={(value) => {
            ticketTypeService.delete(value.id).then(({ data }) => {
              setTicketTypes(data);
            });
          }}
        />
      )}
      {addModalOpen && (
        <Modal isOpen={addModalOpen} className="text-dark">
          <ModalHeader>
            {formik.values.id > 0 ? "Edit ticket type" : "Create ticket type"}
          </ModalHeader>
          <ModalBody>
            <form onSubmit={formik.handleSubmit}>
              <Row>
                <Col>
                  <label htmlFor="ttype" className="mb-2">
                    Ticket type name
                  </label>
                  <input
                    id="ttype"
                    name="ttype"
                    onChange={formik.handleChange}
                    value={formik.values.ttype}
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
                    onClick={() => {
                      formik.setValues({ ...formik.initialValues });
                      setAddModalOpen(false);
                    }}
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

export default TicketTypes;
