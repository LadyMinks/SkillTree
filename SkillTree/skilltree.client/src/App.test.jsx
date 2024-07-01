import { render, screen, waitFor } from '@testing-library/react';
import '@testing-library/jest-dom/extend-expect';
import App from './App';

// Mock fetch API
global.fetch = jest.fn(() =>
    Promise.resolve({
        json: () => Promise.resolve([
            { grade: 'Proficient', description: '<p>Proficient level forecast</p>', name: 'Test Forecast 1' },
            { grade: 'Beginning', description: '<p>Beginning level forecast</p>', name: 'Test Forecast 2' },
        ]),
    })
);

describe('App Component', () => {
    beforeEach(() => {
        fetch.mockClear();
    });

    test('shows loading initially', () => {
        render(<App />);
        expect(screen.getByText('Loading...')).toBeInTheDocument();
    });

    test('renders forecasts after data fetch', async () => {
        render(<App />);

        // Wait for forecasts to be rendered
        await waitFor(() => {
            expect(screen.getByText('Semester')).toBeInTheDocument();
        });

        // Check if the fetched forecasts are rendered correctly
        expect(screen.getByText('Test Forecast 1')).toBeInTheDocument();
        expect(screen.getByText('Test Forecast 2')).toBeInTheDocument();
    });
});
