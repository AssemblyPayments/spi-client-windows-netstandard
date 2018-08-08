using System;

namespace SPIClient
{
    public interface ISpi
    {
        SpiConfig Config { get; }
        SpiFlow CurrentFlow { get; }
        PairingFlowState CurrentPairingFlowState { get; }
        SpiStatus CurrentStatus { get; }
        TransactionFlowState CurrentTxFlowState { get; }

        event EventHandler<PairingFlowState> PairingFlowStateChanged;
        event EventHandler<Secrets> SecretsChanged;
        event EventHandler<SpiStatusEventArgs> StatusChanged;
        event EventHandler<TransactionFlowState> TxFlowStateChanged;

        MidTxResult AcceptSignature(bool accepted);
        bool AckFlowEndedAndBackToIdle();
        MidTxResult CancelTransaction();
        void Dispose();
        SpiPayAtTable EnablePayAtTable();
        SpiPreauth EnablePreauth();
        Message.SuccessState GltMatch(GetLastTransactionResponse gltResponse, string posRefId);
        Message.SuccessState GltMatch(GetLastTransactionResponse gltResponse, TransactionType expectedType, int expectedAmount, DateTime requestTime, string posRefId);
        InitiateTxResult InitiateCashoutOnlyTx(string posRefId, int amountCents);
        InitiateTxResult InitiateGetLastTx();
        InitiateTxResult InitiateMotoPurchaseTx(string posRefId, int amountCents);
        InitiateTxResult InitiatePurchaseTx(string posRefId, int amountCents);
        InitiateTxResult InitiatePurchaseTxV2(string posRefId, int purchaseAmount, int tipAmount, int cashoutAmount, bool promptForCashout);
        InitiateTxResult InitiateRecovery(string posRefId, TransactionType txType);
        InitiateTxResult InitiateRefundTx(string posRefId, int amountCents);
        InitiateTxResult InitiateSettlementEnquiry(string posRefId);
        InitiateTxResult InitiateSettleTx(string posRefId);
        bool Pair();
        void PairingCancel();
        void PairingConfirmCode();
        bool SetEftposAddress(string address);
        bool SetPosId(string posId);
        void Start();
        SubmitAuthCodeResult SubmitAuthCode(string authCode);
        bool Unpair();
    }
}