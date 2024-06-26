import React, { useEffect, useContext } from 'react';
import 'bootstrap/dist/css/bootstrap.css';
import PointItem from '../../PointItem/PointItem';
import { PointContext } from '../../context/main-context';

const FlightPoints = () => {

    const {points, fetchPoints, currentFlight} = useContext(PointContext)

    useEffect(() => {
        fetchPoints();
        console.log(points)
    },[currentFlight]);

    
    return (
        <>
            <div>
                {points.routePoints && points.routePoints.map((element, index) => (
                    <PointItem
                        key={element.id}
                        index={index}
                        id={element.id}
                        order={element.order}
                        isEditable={element.isEditable}
                        latitude={element.latitude}
                        longitude={element.longitude}
                        remarks={element.remarks}
                        altitude={element.altitude}
                        onRemoveData={fetchPoints}
                    />))
                }
            </div>
        </>
    );
};

export default FlightPoints;