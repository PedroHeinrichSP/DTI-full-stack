import { Routes, Route, Navigate } from "react-router-dom";
import Navbar from "./components/Navbar";
import InvitedPage from "./routes/InvitedPage";
import AcceptedPage from "./routes/AcceptedPage";

function App() {
  return (
    <div className="min-h-screen bg-white dark:bg-gray-900 text-gray-900 dark:text-gray-100">
      <Navbar />
      <main className="p-4">
        <Routes>
          <Route path="/" element={<Navigate to="/invited" replace />} />
          <Route path="/invited" element={<InvitedPage />} />
          <Route path="/accepted" element={<AcceptedPage />} />
        </Routes>
      </main>
    </div>
  );
}

export default App;
