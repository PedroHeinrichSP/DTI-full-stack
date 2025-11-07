import { motion } from "framer-motion";

interface ConfirmModalProps {
  message: string;
  suggestedPrice: number;
  onConfirm: () => void;
  onCancel: () => void;
}

export default function ConfirmModal({
  message,
  suggestedPrice,
  onConfirm,
  onCancel,
}: ConfirmModalProps) {
  return (
    <motion.div
      className="fixed inset-0 bg-black/50 flex items-center justify-center z-50"
      initial={{ opacity: 0 }}
      animate={{ opacity: 1 }}
    >
      <motion.div
        className="bg-white dark:bg-zinc-800 p-6 rounded-2xl shadow-xl max-w-sm w-full text-center"
        initial={{ scale: 0.9 }}
        animate={{ scale: 1 }}
      >
        <h2 className="text-xl font-semibold mb-4 text-zinc-900 dark:text-zinc-100">
          Please confirm
        </h2>
        <p className="text-zinc-700 dark:text-zinc-300 mb-4">{message}</p>
        <p className="font-bold text-lg text-blue-600 dark:text-blue-400 mb-6">
          New price: $ {suggestedPrice.toFixed(2)}
        </p>
        <div className="flex justify-center gap-4">
          <button
            onClick={onCancel}
            className="px-4 py-2 bg-gray-300 dark:bg-zinc-700 rounded-xl hover:bg-gray-400 transition"
          >
            Cancel
          </button>
          <button
            onClick={onConfirm}
            className="px-4 py-2 bg-blue-600 text-white rounded-xl hover:bg-blue-700 transition"
          >
            Confirm
          </button>
        </div>
      </motion.div>
    </motion.div>
  );
}
