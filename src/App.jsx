import React, { useState, useEffect } from 'react';
import axios from 'axios';

function App() {
    const [breakdowns, setBreakdowns] = useState([]);
    const [form, setForm] = useState({
        breakdownReference: '',
        companyName: '',
        driverName: '',
        registrationNumber: '',
        breakdownDate: ''
    });

    useEffect(() => {
        fetchBreakdowns();
    }, []);

    const fetchBreakdowns = async () => {
        try {
            const response = await axios.get('http://localhost:5231/api/breakdowns');
            setBreakdowns(response.data);
        } catch (error) {
            console.error('Error fetching breakdowns:', error);
        }
    };

    const handleChange = (e) => {
        setForm({ ...form, [e.target.name]: e.target.value });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            // Check if breakdownReference already exists in the fetched breakdowns
            const existingBreakdown = breakdowns.find(b => b.breakdownReference === form.breakdownReference);

            if (existingBreakdown) {
                // If it exists, update the record
                await axios.put(`http://localhost:5231/api/breakdowns/${form.breakdownReference}`, form);
            } else {
                // If it does not exist, create a new record
                await axios.post('http://localhost:5231/api/breakdowns', form);
            }

            // Clear the form
            setForm({
                breakdownReference: '',
                companyName: '',
                driverName: '',
                registrationNumber: '',
                breakdownDate: ''
            });

            // Fetch the latest data after the form is submitted successfully
            fetchBreakdowns();
        } catch (error) {
            console.error('Error submitting form:', error);
        }
    };

    return (
        <div>
            <h1>Breakdowns</h1>
            <ul>
                {breakdowns.map((b) => (
                    <li key={b.breakdownReference}>
                        {b.companyName} - {b.driverName} - {b.registrationNumber} - {b.breakdownDate}
                    </li>
                ))}
            </ul>
            <h2>{form.breakdownReference ? 'Update Breakdown' : 'Create Breakdown'}</h2>
            <form onSubmit={handleSubmit}>
                <input
                    type="text"
                    name="breakdownReference"
                    placeholder="Breakdown Reference"
                    value={form.breakdownReference}
                    onChange={handleChange}
                    required
                />
                <input
                    type="text"
                    name="companyName"
                    placeholder="Company Name"
                    value={form.companyName}
                    onChange={handleChange}
                    required
                />
                <input
                    type="text"
                    name="driverName"
                    placeholder="Driver Name"
                    value={form.driverName}
                    onChange={handleChange}
                    required
                />
                <input
                    type="text"
                    name="registrationNumber"
                    placeholder="Registration Number"
                    value={form.registrationNumber}
                    onChange={handleChange}
                    required
                />
                <input
                    type="datetime-local"
                    name="breakdownDate"
                    value={form.breakdownDate}
                    onChange={handleChange}
                    required
                />
                <button type="submit">Submit</button>
            </form>
        </div>
    );
}

export default App;
