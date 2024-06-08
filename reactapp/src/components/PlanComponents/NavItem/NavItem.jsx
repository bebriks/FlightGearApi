import React, { useEffect, useState, useContext } from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import { OverlayTrigger, Button, Popover } from "react-bootstrap";
import "../NavItem/NavItem.css";
import PlanPoints from "../frames/flight-frame/flight-frame";

import plane from '../NavItem/imgs/plane.png';
import analytics from '../NavItem/imgs/analytics.png';
import docs from '../NavItem/imgs/docs.png';
import flightPlans from '../NavItem/imgs/flight-plans.png';
import flightPoints from '../NavItem/imgs/flight-stages.png';

import { getData, handlerAddFlight } from "../../../utils/common";
import plus from '../../../assets/img/Union.png';
import FlightPoints from "../frames/flight-points-frame/flight-points-frame";
import PointItem from "../PointItem/PointItem";
import { PointContext } from "../context/main-context";

const NavHeader = () => {
  const [showPopoverPoints, setShowPopoverPoints] = useState(false);
  const [showPopoverPlans, setShowPopoverPlans] = useState(false);
  const [showPopoverCurrentFlight, setShowPopoverCurrentFlight] = useState(false);

  //const [flight, setFlight] = useState([]);
  const [sendingFlightData, setSendingFlightData] = useState([]);
  const [isFormVisible, setIsFormVisible] = useState(false);

  const { points, flights, addFlight, airports } = useContext(PointContext);

  const handleCreateNewFlightForm = async (evt) => {
    evt.preventDefault();
    setIsFormVisible(!isFormVisible);
    //const formData = getData(document.getElementById('formFlight'));
    //addFlight(formData, sendingFlightData, setSendingFlightData);
    evt.target.classList.add('disabled');
  };

  const handleClickAddFlight = (evt) => {
    evt.preventDefault();

    const formData = getData(document.getElementById('formFlight'));
    addFlight(formData, sendingFlightData, setSendingFlightData);
    document.querySelector('.btn-create').classList.remove('disabled');
    setIsFormVisible(!isFormVisible);
  };

  const handleChooseCurrentFlight = () => {
    setShowPopoverPoints(true);
    setShowPopoverCurrentFlight(false);
  };

  const popoverPoints = (
    <Popover id="popover-basic">
      <Popover.Header as="h1">All Flights</Popover.Header>
      <Popover.Body>
        <PlanPoints />
      </Popover.Body>
    </Popover>
  );

  const popoverPlans = (
    <Popover id="popover-basic">
      <Popover.Header as="h1">All Flights!</Popover.Header>
      <Popover.Body>
        {/* <FlightsPlanTable /> */}
      </Popover.Body>
    </Popover>
  );

  const popoverCurrentFlight = (
    <Popover id="popover-basic">
      <Popover.Header as="h1">Current Flight</Popover.Header>
      <Popover.Body>
        {getCurForm()}
      </Popover.Body>
    </Popover>
  );

  function getCurForm() {
    return (
      <main className="container">
        <div className={`row`}>
          <div className="d-flex justify-content-center">
            <button className="btn bg-primary me-auto btn-hover" onClick={handleChooseCurrentFlight}>Choose current flight</button>
            <button className="btn-create btn bg-primary btn-hover" onClick={handleCreateNewFlightForm}>Create New</button>
          </div>
          {isFormVisible && (
            <form className={``} id="formFlight">
              <ul className="list-unstyled m-0">
                <li className="d-flex align-items-center">
                  <p className="fs-5">Flight name:</p>
                  <input className="form-control ms-auto" defaultValue={`flight title`} type="text" name="title" required />
                </li>
                <li className="d-flex align-items-center">
                  <p className="fs-5">Remarks:</p>
                  <textarea className="form-control ms-auto" type="text" name="remarks"/>
                </li>
                <li className="d-flex align-items-center">
                  <p className="fs-5">Start Airport:</p>
                  <input className="departureRunwayId form-control ms-auto" type="text" list="destination-list-1" name="departureRunwayId" />
                  <datalist id="destination-list-1">
                    {airports.airports && airports.airports.map((el) => (
                      <option>{`${el.city}, ${el.title}`}</option>
                    ))}
                  </datalist>
                </li>
                <li className="d-flex align-items-center">
                  <p className="fs-5">End Airport:</p>
                  <input className="arrivalRunwayId form-control ms-auto" type="text" list="destination-list-2" name="arrivalRunwayId" />
                  <datalist id="destination-list-2">
                    {airports.airports && airports.airports.map((el) => (
                      <option>{`${el.city}, ${el.title}`}</option>
                    ))}
                  </datalist>
                </li>
                {/* <li className="d-inline points m-1">
                  <p className="border-bottom border-secondary m-0 mx-auto align-self-center">Points:</p>
                  <div className="point-container form-control m-1 w-auto">
                    <FlightPoints />
                  </div>
                </li> */}
                <li className="mt-3 d-flex align-items-center justify-content-center">
                  <button className="btn btn-primary btn-hover" onClick={handleClickAddFlight} type="submit">
                    Save
                  </button>
                </li>
              </ul>
            </form>
          )}
        </div>
      </main>
    );
  }

  return (
    <header className="container-fluid bg-not-light">
      <div>
        <nav className="d-flex flex-row justify-content-between">
          <ul className="nav nav-pills align-items-center">
            <li className="nav-item mx-2">
              <OverlayTrigger
                trigger="click"
                placement="bottom"
                show={showPopoverCurrentFlight}
                onToggle={(nextShow) => setShowPopoverCurrentFlight(nextShow)}
                overlay={popoverCurrentFlight}
                rootClose={true}
              >
                <Button className="btn flight-plans" variant="transparent">
                  <img src={flightPoints} width="53" alt="Flight Plans" />
                </Button>
              </OverlayTrigger>
            </li>
            <li className="nav-item mx-2">
              <OverlayTrigger
                trigger="click"
                placement="bottom"
                show={showPopoverPoints}
                onToggle={(nextShow) => setShowPopoverPoints(nextShow)}
                overlay={popoverPoints}
                rootClose={true}
              >
                <Button className="btn flight-points" variant="transparent">
                  <img src={flightPlans} width="28" alt="Flight Points" />
                </Button>
              </OverlayTrigger>
            </li>
            <li className="nav-item mx-2 hidden">
              <OverlayTrigger
                trigger="click"
                placement="bottom"
                show={showPopoverPlans}
                onToggle={(nextShow) => setShowPopoverPlans(nextShow)}
                overlay={popoverPlans}
                rootClose={true}
              >
                <Button className="btn flight-plans" variant="transparent">
                  <img src={flightPlans} width="28" alt="Flight Plans" />
                </Button>
              </OverlayTrigger>
            </li>
          </ul>
          <ul className="nav nav-pills">
            <li className="nav-item mx-2">
              <a href="/" className="nav-link" aria-current="page" alt="Planner" title="Planner">
                <img src={plane} width="40" alt="Planner" />
              </a>
            </li>
            <li className="nav-item mx-2">
              <a href="#" className="nav-link" alt="Docs" title="Docs">
                <img src={docs} width="40" alt="Docs" />
              </a>
            </li>
            <li className="nav-item mx-2">
              <a href="/analyze" className="nav-link" alt="Analytics" title="Analytics">
                <img src={analytics} width="40" alt="Analytics" />
              </a>
            </li>
          </ul>
        </nav>
      </div>
    </header>
  );
};

export default NavHeader;