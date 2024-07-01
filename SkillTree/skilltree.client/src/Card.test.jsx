/* eslint-disable no-undef */
import { render, screen } from '@testing-library/react';
import '@testing-library/jest-dom/extend-expect';
import Card from './Card';

describe('Card Component', () => {
    const forecast = {
        grade: 'Proficient',
        description: '<p>Proficient level forecast</p>',
        name: 'Test Forecast'
    };

    test('renders correctly with Proficient grade', () => {
        render(<Card forecast={forecast} />);

        // Check if the grade is displayed correctly
        expect(screen.getByText('Proficient')).toBeInTheDocument();

        // Check if the style is applied correctly
        const cardDiv = screen.getByText('Proficient').parentElement;
        expect(cardDiv).toHaveStyle('background: linear-gradient(to right, #027b13 0%, #14d102 100%)');
    });

    test('converts HTML to plain text', () => {
        render(<Card forecast={forecast} />);

        // Check if the description is converted to plain text
        expect(screen.getByText('Proficient level forecast')).toBeInTheDocument();
    });

    test('renders with mock forecast object', () => {
        render(<Card forecast={forecast} />);

        // Check if the name is displayed correctly
        expect(screen.getByText('Test Forecast')).toBeInTheDocument();
    });

    test('renders correctly with Orienting grade', () => {
        const orientingForecast = { ...forecast, grade: 'Orienting' };
        render(<Card forecast={orientingForecast} />);

        expect(screen.getByText('Orienting')).toBeInTheDocument();
        const cardDiv = screen.getByText('Orienting').parentElement;
        expect(cardDiv).toHaveStyle('background: linear-gradient(to right, #7b0202 0%, #d10202 100%)');
    });

    test('renders correctly with Beginning grade', () => {
        const beginningForecast = { ...forecast, grade: 'Beginning' };
        render(<Card forecast={beginningForecast} />);

        expect(screen.getByText('Beginning')).toBeInTheDocument();
        const cardDiv = screen.getByText('Beginning').parentElement;
        expect(cardDiv).toHaveStyle('background: linear-gradient(to right, #6b7b02 0%, #cbeb1c 100%)');
    });

    test('renders correctly with Advanced grade', () => {
        const advancedForecast = { ...forecast, grade: 'Advanced' };
        render(<Card forecast={advancedForecast} />);

        expect(screen.getByText('Advanced')).toBeInTheDocument();
        const cardDiv = screen.getByText('Advanced').parentElement;
        expect(cardDiv).toHaveStyle('background: linear-gradient(to right, #0e2e03 0%, #0b6605 100%)');
    });
});
