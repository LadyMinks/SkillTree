/* eslint-disable react/no-unknown-property */
import { useEffect, useState } from 'react';
import './App.css';
import Card from './Card.jsx'


function App() {
    const [forecasts, setForecasts] = useState();

    useEffect(() => {
        populateWeatherData();

    }, []);


    const contents = forecasts === undefined
        ? <p>Loading...</p>
        :
        <div>
            <h1 className="header">Semester</h1>
            <div className="flex-container" aria-labelledby="tabelLabel">
                {forecasts.map(forecast => {
                    return (
                        <div key={forecast.name}>
                            <Card forecast={forecast} ></Card>
                        </div>
                    )
                }
                )}
            </div>
        </div>
        ;

    return (
        <div>

            {contents}

        </div>
    );

    async function populateWeatherData() {
        /*
        const response = await fetch("https://localhost:7013/test", {
            mode: 'cors', headers: {
                'Access-Control-Allow-Origin': '*'
            }
        });
        */

        const response = await fetch("weatherforecast");
        const data = await response.json();

        setForecasts(data);
    }
}

export default App;