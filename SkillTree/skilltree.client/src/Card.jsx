/* eslint-disable react/prop-types */
import './App.css';

function Card({ forecast }) {

    let style;

    switch (forecast.grade) {
        case "Orienting":
            style = { background: "linear-gradient(to right, #7b0202 0%, #d10202 100%)" }
            break;
        case "Beginning":
            style = { background: "linear-gradient(to right, #6b7b02 0%, #cbeb1c 100%)" }
            break;
        case "Proficient":
            style = { background: "linear-gradient(to right, #027b13 0%, #14d102 100%)" }
            break;
        case "Advanced":
            style = { background: "linear-gradient(to right, #0e2e03 0%, #0b6605 100%)" }
            break;
    }

  
    return (<>
        <div className="flex-items">
            <label>
                <input type="checkbox" />
                <div className="card">
                    <div style={style}>
                        {forecast.grade}
                    </div>
                    <div className="back">
                        {forecast.description}
                    </div>
                </div>
            </label>
            <h6 className="center">{forecast.name}</h6>
        </div>
    </>)
}

export default Card;