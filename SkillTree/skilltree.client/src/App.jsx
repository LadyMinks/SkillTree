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

                    

                    
                    //    let style;
                //if (forecast.grade == "Orienting") {
                //    style = { background: "linear-gradient(to right, #7b0202 0%, #d10202 100%)" }
                //}
                //else if (forecast.grade == "Beginning") {
                //    style = { background: "linear-gradient(to right, #6b7b02 0%, #cbeb1c 100%)" }
                //}
                //else if (forecast.grade == "Proficient") {
                //    style = { background: "linear-gradient(to right, #027b13 0%, #14d102 100%)" }
                //}
                //else if (forecast.grade == "Advanced") {
                //    style = { background: "linear-gradient(to right, #0e2e03 0%, #0b6605 100%)" }
                //}
                    //return (<>
                    //    <div className="flex-items">
                    //        <label>
                    //            <input type="checkbox" />
                    //            <div className="card">
                    //                <div style={style}>{forecast.grade}</div>
                    //                <div className="back">{forecast.description}</div>
                    //            </div>
                    //        </label>
                    //        <h6 className="center">{forecast.name}</h6>
                    //    </div>
                    //</>)
                
               
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