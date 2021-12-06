import React from 'react';
import L, { LatLngExpression } from "leaflet";
import "leaflet/dist/leaflet.css";
import { Map, TileLayer, Marker, Popup } from 'react-leaflet';

const position: LatLngExpression = [59.91174337077401, 10.750425582038146];

export default function GoogleMapComponents(this: any) {
    return (
        <>
            <Map center={position} zoom={13} scrollWheelZoom={false}>
                <TileLayer
                    attribution='&copy; <a href="http://osm.org/copyright">OpenStreetMap</a> contributors'
                    url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
                />
                <Marker position={position}>
                    <Popup>
                        A pretty CSS3 popup. <br /> Easily customizable.
                    </Popup>
                </Marker>
            </Map>
        </>
    );
}
