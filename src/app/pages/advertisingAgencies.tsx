import { useFormik } from "formik";
import moment from "moment";
import { useState } from "react";
import { Button, Col, Modal, ModalBody, ModalHeader, Row } from "reactstrap";
import MyTable from "../reusable/MyTable";
import advertisingAgenciesService from "../services/advertisingAgenciesService";
import eventService from "../services/eventService";
import { TAdvertisingAgencies, TEvent } from "../types";

const AdvertisingAgencies = (): JSX.Element => {
  const [agencies, setAgecnies] = useState<TAdvertisingAgencies[]>([]);
  const [addModalOpen, setAddModalOpen] = useState<boolean>(false);
  const [events, setEvents] = useState<TEvent[]>([]);

  useState(() => {
    advertisingAgenciesService.getAll().then(({ data }) => {
      setAgecnies(data);
    });
    eventService.getAll().then(({ data }) => {
      setEvents(data);
    });
  });
  const formik = useFormik<TAdvertisingAgencies>({
    initialValues: {
      agencyId: 0,
      aname: "",
      aaddress: "",
      abankAccountNumber: "",
      adateOfIssue: "",
      eventId: 0,
    },
    onSubmit: (values) => {
      if (values.agencyId === 0)
        advertisingAgenciesService
          .create(values)
          .then(({ data }) => setAgecnies(data));
      else
        advertisingAgenciesService.update(values).then(({ data }) => {
          setAgecnies(data);
        });
      setAddModalOpen(false);
    },
  });
  return (
    <>
      <Button onClick={() => setAddModalOpen(true)} className="w-100">
        Add record
      </Button>
      {agencies.length > 0 && (
        <MyTable
          data={agencies}
          onDeleteClick={(value) => {
            advertisingAgenciesService
              .delete(value.agencyId)
              .then(({ data }) => {
                setAgecnies(data);
              });
          }}
          onEditClick={(value) => {
            formik.setValues({ ...value });
            setAddModalOpen(true);
          }}
        />
      )}
      {addModalOpen && (
        <Modal isOpen={addModalOpen} className="text-dark">
          <ModalHeader>
            {formik.values.agencyId > 0 ? "Edit agency" : "Create agency"}
          </ModalHeader>
          <ModalBody>
            <form onSubmit={formik.handleSubmit}>
              <Row>
                <Col>
                  <label htmlFor="aname" className="mb-2">
                    Agency name
                  </label>
                  <input
                    id="aname"
                    name="aname"
                    onChange={formik.handleChange}
                    value={formik.values.aname}
                    className="form-control"
                  ></input>
                </Col>
              </Row>
              <Row>
                <Col>
                  <label htmlFor="aaddress" className="mb-2">
                    Agency address
                  </label>
                  <input
                    id="aaddress"
                    name="aaddress"
                    onChange={formik.handleChange}
                    value={formik.values.aaddress}
                    className="form-control"
                  ></input>
                </Col>
              </Row>
              <Row>
                <Col>
                  <label htmlFor="abankAccountNumber" className="mb-2">
                    Agency bank account number
                  </label>
                  <input
                    id="abankAccountNumber"
                    name="abankAccountNumber"
                    onChange={formik.handleChange}
                    value={formik.values.abankAccountNumber}
                    className="form-control"
                  ></input>
                </Col>
              </Row>
              <Row>
                <Col>
                  <label htmlFor="adateOfIssue" className="mb-2">
                    Agency date of Issue
                  </label>
                  <input
                    type="date"
                    id="adateOfIssue"
                    name="adateOfIssue"
                    onChange={formik.handleChange}
                    value={moment(formik.values.adateOfIssue).format(
                      "YYYY-MM-DD"
                    )}
                    className="form-control"
                  ></input>
                </Col>
              </Row>
              <Row>
                <Col>
                  <label htmlFor="eventId" className="mb-2">
                    Agency event
                  </label>
                  <select
                    id="eventId"
                    name="eventId"
                    onChange={formik.handleChange}
                    value={formik.values.eventId}
                    className="form-control"
                  >
                    {events.map((event) => {
                      return (
                        <option value={event.id} key={event.id}>
                          {event.ename}
                        </option>
                      );
                    })}
                  </select>
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

export default AdvertisingAgencies;
